<?php
	 class C_tpld_param extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_PARAM.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_PARAM.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_paramid' =>  $this->input->get_post('tpld_paramid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'paramfield' =>   $this->input->get_post('paramfield', TRUE)
                ,'showas' =>   $this->input->get_post('showas', TRUE)
            );
            $tpld_param = $this->m_tpld_param->setRow($data);
            print json_encode($tpld_param);
    }
    function newRow() {
            log_message('debug', 'TPLD_PARAM.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_paramid' =>  $this->input->get_post('tpld_paramid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'paramfield' =>   $this->input->get_post('paramfield', TRUE)
                ,'showas' =>   $this->input->get_post('showas', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_param= $this->m_tpld_param->newRow($instanceid,$data);
            $return = $tpld_param;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_PARAM.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_param = $this->m_tpld_param->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_param
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_param= $this->m_tpld_param->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_param= $this->m_tpld_param->getRows($sort);
                }
            }else{
              $tpld_param= $this->m_tpld_param->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_param
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_PARAM.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_param= $this->m_tpld_param->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_param
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLD_PARAM.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_param= $this->m_tpld_param->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_param
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLD_PARAM.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_paramid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_param->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpld_param', 'm_tpld_param');
    }
}
?>