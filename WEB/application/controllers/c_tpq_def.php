<?php
	 class C_tpq_def extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPQ_DEF.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPQ_DEF.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpq_defid' =>  $this->input->get_post('tpq_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thesessionid' =>   $this->input->get_post('thesessionid', TRUE)
                ,'thedevice' =>   $this->input->get_post('thedevice', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'archtime' =>   $this->input->get_post('archtime', TRUE)
                ,'querytime' =>   $this->input->get_post('querytime', TRUE)
                ,'isurgent' =>   $this->input->get_post('isurgent', TRUE)
                ,'repeattimes' =>   $this->input->get_post('repeattimes', TRUE)
                ,'repeatinterval' =>   $this->input->get_post('repeatinterval', TRUE)
            );
            $tpq_def = $this->m_tpq_def->setRow($data);
            print json_encode($tpq_def);
    }
    function newRow() {
            log_message('debug', 'TPQ_DEF.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpq_defid' =>  $this->input->get_post('tpq_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'thesessionid' =>   $this->input->get_post('thesessionid', TRUE)
                ,'thedevice' =>   $this->input->get_post('thedevice', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'archtime' =>   $this->input->get_post('archtime', TRUE)
                ,'querytime' =>   $this->input->get_post('querytime', TRUE)
                ,'isurgent' =>   $this->input->get_post('isurgent', TRUE)
                ,'repeattimes' =>   $this->input->get_post('repeattimes', TRUE)
                ,'repeatinterval' =>   $this->input->get_post('repeatinterval', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpq_def= $this->m_tpq_def->newRow($instanceid,$data);
            $return = $tpq_def;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPQ_DEF.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpq_def = $this->m_tpq_def->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpq_def
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
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpq_def= $this->m_tpq_def->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpq_def= $this->m_tpq_def->getRows($sort);
                }
            }else{
              $tpq_def= $this->m_tpq_def->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpq_def
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPQ_DEF.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpq_def= $this->m_tpq_def->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpq_def
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
        log_message('debug', 'TPQ_DEF.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'thedevice', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpq_def= $this->m_tpq_def->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpq_def
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
        log_message('debug', 'TPQ_DEF.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpq_defid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpq_def->deleteRow($tempId);
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
        $this->load->model('M_tpq_def', 'm_tpq_def');
    }
}
?>