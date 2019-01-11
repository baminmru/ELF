﻿
    <?php
	 class C_v_autotpld_snabtop extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function newRow() {
            log_message('debug', 'AUTOTPLD_SNABTOP.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
            $name  =  $this->input->get_post('name', TRUE);
            $objtype  =  $this->input->get_post('objtype', TRUE);
            $autotpld_snabtop= $this->m_v_autotpld_snabtop->newRow($name,$objtype);
            $return = $autotpld_snabtop;
            print json_encode($return);
    }
    function getRows() {
            log_message('debug', 'AUTOTPLD_SNABTOP.getRows post : '.json_encode($this->input->post(NULL, FALSE)));
           $start=$this->input->get('start', FALSE);
           $limit=$this->input->get('limit', FALSE);
       $group = $this->input->get('group', FALSE);  
      $sort = $this->input->get('sort', FALSE);
      if(!$sort && $group) $sort = $group;
      if(!$sort || $group == $sort) 
          {
              $sort = json_decode($sort);
              //$sort[] = array('property'=>'field_name', 'direction'=>'ASC');
              $sort = json_encode($sort);
          }
          $filter = $this->input->get('filter', FALSE);
           $autotpld_snabtop= $this->m_v_autotpld_snabtop->getRowsSL($start,$limit,$sort,$filter);
           print json_encode($autotpld_snabtop);
    }
    function deleteRow() {
        log_message('debug', 'AUTOTPLD_SNABTOP.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_v_autotpld_snabtop->deleteRow($tempId);
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
        $this->load->model('M_v_autotpld_snabtop', 'm_v_autotpld_snabtop');
    }
}